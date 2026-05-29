import React, { useState, useEffect } from 'react';

interface Vehicle {
  id: string
  make: string
  model: string
  year: number
}

interface Engine {
  id: string
  engineName: string
  manufacturer: string
  mountPattern: number
  engineSize: number
}

interface CompatibilityResult {
  id: string
  isCompatible: boolean
  difficultyLevel: string
  engine: Engine
  notes: string
}

function App() {

  const [vehicles, setVehicles] = useState<Vehicle[]>([])
  const [engines, setEngines] = useState<Engine[]>([])
  const [selectedEngineId, setSelectedEngineId] = useState<string>("")
  const [selectedVehicleId, setSelectedVehicleId] = useState<string>("")
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const [compatibilityResult, setCompatibilityResult] = useState<CompatibilityResult[]>([])

  useEffect(() => {
    setIsLoading(true)
    fetch('http://localhost:5069/api/vehicles')
      .then(res => res.json())
      .then(data => {
        console.log(data)
        setVehicles(data)
        setIsLoading(false)
      })
  }, [])

  useEffect(() => {
    setIsLoading(true)
    fetch('http://localhost:5069/api/engines')
    .then(res => res.json())
    .then(data => {
      console.log(data)
      setEngines(data)
      setIsLoading(false)
    })
  }, [])
  

  function handleCheckCompatibility() {
    fetch(`http://localhost:5069/api/compatibility/${selectedVehicleId}`)
      .then(res => res.json())
      .then(data => setCompatibilityResult(data))
  }

  return (
  <div className="min-h-screen bg-gray-950 text-white p-8">
    <div className="max-w-2xl mx-auto">
      <h1 className="text-4xl font-bold text-orange-500 mb-2">SwapCheck 🔧</h1>
      <p className="text-gray-400 mb-8">Engine Swap Compatibility Tool</p>

      <div className="bg-gray-900 rounded-xl p-6 mb-6">
        <label className="block text-sm text-gray-400 mb-2">Select a Vehicle</label>
        <select
          className="w-full bg-gray-800 text-white rounded-lg p-3 border border-gray-700"
          onChange={e => setSelectedVehicleId(e.target.value)}
        >
          <option value="">-- Select a Vehicle --</option>
          {vehicles.map(vehicle => (
            <option key={vehicle.id} value={vehicle.id}>
              {vehicle.year} {vehicle.make} {vehicle.model}
            </option>
          ))}
        </select>

        <label className="block text-sm text-gray-400 mb-2">Select a Engine</label>
        <select
          className="w-full bg-gray-800 text-white rounded-lg p-3 border border-gray-700"
          onChange={e => setSelectedEngineId(e.target.value)}
        >
          <option value="">-- Select a Engine --</option>
          {engines.map(engine => (
            <option key={engine.id} value={engine.id}>
             {engine.manufacturer} {engine.engineName}
            </option>
          ))}
        </select>

        <button
          onClick={handleCheckCompatibility}
          className="mt-4 w-full bg-orange-500 hover:bg-orange-600 text-white font-semibold py-3 rounded-lg transition-colors"
        >
          Check Compatibility
        </button>
      </div>

      {compatibilityResult.map(result => (
        <div
          key={result.id}
          className={`rounded-xl p-6 mb-4 border ${result.isCompatible ? 'bg-green-950 border-green-700' : 'bg-red-950 border-red-700'}`}
        >
          <h3 className="text-xl font-bold mb-2">{result.engine.engineName}</h3>
          <p className={result.isCompatible ? 'text-green-400' : 'text-red-400'}>
            {result.isCompatible ? '✅ Compatible' : '❌ Not Compatible'}
          </p>
          <p className="text-gray-400 mt-1">Difficulty: {result.difficultyLevel}</p>
          <p className="text-gray-500 mt-1 text-sm">{result.notes}</p>
        </div>
      ))}
    </div>
  </div>
)
}

export default App;
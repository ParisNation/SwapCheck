import React, { useState, useEffect } from 'react';

interface Vehicle {
  id: string
  make: string
  model: string
  year: number
}

interface Engine {
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

  function handleCheckCompatibility() {
    fetch(`http://localhost:5069/api/compatibility/${selectedVehicleId}`)
      .then(res => res.json())
      .then(data => setCompatibilityResult(data))
  }

  return (
    <div>
      <h1>SwapCheck</h1>
      <div>
        {isLoading && <p>Loading vehicles...</p>}
        <select onChange={e => setSelectedVehicleId(e.target.value)}>
        {vehicles.map(vehicle => (
          <option key={vehicle.id} value={vehicle.id}>
            {vehicle.make} {vehicle.model} {vehicle.year}
          </option>
          ))
        }
        </select>
      </div>
      <button onClick={handleCheckCompatibility}>
        Check Compatibility
      </button>

     {compatibilityResult.map(result => (
      <div key={result.id}>
        <h3>{result.engine.engineName}</h3>
        <p>Compatible: {result.isCompatible  ? 'Yes' : 'No'}</p>
        <p>Difficulty: {result.difficultyLevel}</p>
        <p>Notes: {result.notes}</p>
      </div>
     ))}
    </div>
  )
}

export default App;
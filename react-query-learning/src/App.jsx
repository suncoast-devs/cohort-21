import React from 'react'
import { useQuery } from 'react-query'

export function App() {
  const { isLoading, error, data } = useQuery('filmData', () =>
    fetch('https://swapi.dev/api/films/').then((res) => res.json())
  )

  console.log({ isLoading, error, data })

  if (isLoading) return 'Loading...'

  if (error) return 'An error has occurred: ' + error.message

  return (
    <div>
      {data.results.map((film) => (
        <p>{film.title}</p>
      ))}
    </div>
  )
}

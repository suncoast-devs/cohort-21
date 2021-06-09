import { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'

export function Film() {
  const [film, setFilm] = useState({
    title: '',
    episode_id: 0,
    opening_crawl: '',
    director: '',
    producer: '',
    release_date: '',
    characters: [],
    planets: [],
    starships: [],
    vehicles: [],
    species: [],
    created: '',
    edited: '',
    url: '',
  })
  const params = useParams()

  useEffect(function () {
    // Load data here
    async function fetchFilm() {
      const response = await fetch(`https://swapi.dev/api/films/${params.id}/`)

      if (response.status === 200) {
        const json = await response.json()
        setFilm(json)
      }
    }

    fetchFilm()
  }, [])

  return (
    <>
      <h2>{film.title}</h2>

      <p className="preamble">Long long ago, in a galaxy far, far away.</p>

      <div className="crawl">{film.opening_crawl}</div>

      <ul className="people-list">
        <li>
          <Link to="/people/1">Hans Solo</Link>
        </li>
        <li>
          <Link to="/people/1">Yoda</Link>
        </li>
        <li>
          <Link to="/people/1">Boba Fett</Link>
        </li>
      </ul>
    </>
  )
}

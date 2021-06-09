import { useState } from 'react'
import { Link } from 'react-router-dom'

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

import axios from 'axios'
import { useQuery } from 'react-query'
import { useParams } from 'react-router-dom'

export function Person() {
  const params = useParams()
  // TODO: Come back to this when we understand react query more
  // const [films, setFilms] = useState([])

  const { isLoading, data: useQueryData } = useQuery(
    ['person', params.id],
    () => axios(`https://swapi.dev/api/people/${params.id}/`)
  )

  // Guard clause, IF we are loading only return a LOADING h2, nothing below
  if (isLoading) {
    return <h2>Loading...</h2>
  }

  // Ugh,
  //
  // `useQueryData` is from the name in useQuery
  // the second `data` is from the name in Axios
  const person = useQueryData.data

  return (
    <>
      <h2>{person.name}</h2>
      <p></p>

      <dl className="person-traits">
        <dt className="trait">Hair Color</dt>
        <dd className="value">{person.hair_color}</dd>
        <dt className="trait">Eye Color</dt>
        <dd className="value">{person.eye_color}</dd>
        <dt className="trait">Birth Year</dt>
        <dd className="value">{person.birth_year}</dd>
      </dl>

      {/* TODO: Uncomment this when loading all the films works */}
      {/* <ul className="film-list">
        {films.map(film => (
          <li key={getIdFromURL(film.url)} className="film">
            <Link to={`/films/${getIdFromURL(film.url)}`}>{film.title}</Link>
          </li>
        ))}
      </ul> */}
    </>
  )
}

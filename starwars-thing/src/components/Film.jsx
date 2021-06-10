import axios from 'axios'
import { useQuery } from 'react-query'
import { useParams } from 'react-router-dom'

export function Film() {
  const params = useParams()
  const { isLoading, data: useQueryData } = useQuery(['film', params.id], () =>
    axios(`https://swapi.dev/api/films/${params.id}/`)
  )

  // TODO: Come back and figure out how to use useQuery to load all the extra characters
  //       We lost that Promise.all work when we trashed useEffect...
  //
  // const [characters, setCharacters] = useState([])

  if (isLoading) {
    return <p>Loading...</p>
  }

  // Ugh,
  //
  // `useQueryData` is from the name in useQuery
  // the second `data` is from the name in Axios
  const film = useQueryData.data

  return (
    <>
      <h2>{film.title}</h2>

      <p className="preamble">Long long ago, in a galaxy far, far away.</p>

      <div className="crawl">{film.opening_crawl}</div>

      {/* TODO: Uncomment this when we figure out how to load the characters again */}
      {/* <ul className="people-list">
        {characters.map(character => (
          <li key={getIdFromURL(character.url)}>
            <Link to={`/people/${getIdFromURL(character.url)}`}>
              {character.name}
            </Link>
          </li>
        ))}
      </ul> */}
    </>
  )
}

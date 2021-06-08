import { Link } from 'react-router-dom'

export function Film() {
  return (
    <>
      <h2>Episode IV: A New Hope</h2>

      <p>Long long ago, in a galaxy far, far away.</p>

      <ul>
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

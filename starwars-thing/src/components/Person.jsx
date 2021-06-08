import { Link } from 'react-router-dom'

export function Person() {
  return (
    <>
      <h2>Hans Solo</h2>
      <p>
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Mollitia ea
        officiis odit, eius magni ratione blanditiis ipsam iste accusantium
        asperiores quae repellat quidem at laborum reprehenderit eligendi saepe
        possimus veniam.
      </p>

      <dl>
        <dt>Hair Color</dt>
        <dd>Blonde</dd>
        <dt>Eye Color</dt>
        <dd>Blue</dd>
        <dt>Birth Year</dt>
        <dd>19 BBY</dd>
      </dl>

      <ul>
        <li>
          <Link to="/films/1">Episode IV: A New Hope</Link>
        </li>
        <li>
          <Link to="/films/1">Episode VII: The Force Awakens</Link>
        </li>
        <li>
          <Link to="/films/1">Episode V: Empire Strikes Back</Link>
        </li>
      </ul>
    </>
  )
}

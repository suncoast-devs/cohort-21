import { Link } from 'react-router-dom'

export function Layout({ children }) {
  return (
    <>
      <header>
        <h1>
          <Link to="/">Star Wars</Link>
        </h1>
      </header>
      <main>{children}</main>
      <footer>
        <p>Built with &hearts; in St. Petersburg, FL.</p>
      </footer>
    </>
  )
}

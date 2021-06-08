import { Link } from 'react-router-dom'

export function Layout({ children }) {
  return (
    <div className="layout">
      <header className="header">
        <div className="container">
          <h1 className="title">
            <Link to="/">Star Wars</Link>
          </h1>
        </div>
      </header>
      <main className="main">
        <div className="container">{children}</div>
      </main>
      <footer className="footer">
        <div className="container">
          <p>Built with &hearts; in St. Petersburg, FL.</p>
        </div>
      </footer>
    </div>
  )
}

import React from 'react'
import logo from './images/sdg-logo.png'
import { TodoList } from './components/TodoList'
import { Route, Switch } from 'react-router'

export function App() {
  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <Switch>
          <Route exact path="/">
            <TodoList />
          </Route>
          <Route path="*">
            <p>Oooops, I don't know about that URL</p>
          </Route>
        </Switch>
      </main>
      <footer>
        <p>
          <img src={logo} height="42" alt="logo" />
        </p>
        <p>&copy; 2020 Suncoast Developers Guild</p>
      </footer>
    </div>
  )
}

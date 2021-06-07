import React, { useEffect, useState } from 'react'
import logo from './images/sdg-logo.png'
import { TodoList } from './components/TodoList'
import { Route, Switch, useParams } from 'react-router'
import axios from 'axios'

function TodoItemPage() {
  const [todoItem, setTodoItem] = useState({
    id: undefined,
    text: '',
    complete: false,
    created_at: undefined,
    updated_at: undefined,
  })
  const params = useParams()

  useEffect(function () {
    // Load the one item who's id is params.id
    async function loadOneItem() {
      const response = await axios.get(
        `https://one-list-api.herokuapp.com/items/${params.id}?access_token=cohort42`
      )

      if (response.status === 200) {
        setTodoItem(response.data)
      }
    }

    loadOneItem()
  }, [])

  return (
    <div>
      <p className={todoItem.complete ? 'completed' : ''}>{todoItem.text}</p>
      <p>Created: {todoItem.created_at}</p>
      <p>Updated: {todoItem.updated_at}</p>
      <button>Delete</button>
    </div>
  )
}

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
          <Route path="/items/:id">
            <TodoItemPage />
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

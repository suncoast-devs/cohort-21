import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { PageFooter } from './components/PageFooter'
import { TodoItemList } from './components/TodoItemList'

export function App() {
  const [todoItems, setTodoItems] = useState([])

  useEffect(async function () {
    const response = await axios.get(
      'https://one-list-api.herokuapp.com/items?access_token=cohort42'
    )

    if (response.status === 200) {
      console.log(response.data)

      // response.data is an array of objects, JUST like I was setup for.
      //
      // "My todo items are the ones that came back from the API"
      setTodoItems(response.data)
    }
  }, [])

  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <ul>
          <TodoItemList todoItems={todoItems} />
        </ul>
        <form>
          <input type="text" placeholder="Whats up?" />
        </form>
      </main>
      <PageFooter />
    </div>
  )
}

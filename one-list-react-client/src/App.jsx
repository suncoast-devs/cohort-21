import axios from 'axios'
import React, { useEffect, useState } from 'react'
import logo from './images/sdg-logo.png'

export function App() {
  const [newTodoText, setNewTodoText] = useState('')
  const [listName, setListName] = useState('cohort42')
  const [todoItems, setTodoItems] = useState([])

  useEffect(
    function () {
      async function loadTheItems() {
        const response = await axios.get(
          `https://one-list-api.herokuapp.com/items?access_token=${listName}`
        )

        if (response.status === 200) {
          console.log(response.data)

          // response.data is an array of objects, JUST like I was setup for.
          //
          // "My todo items are the ones that came back from the API"
          setTodoItems(response.data)
        }
      }

      loadTheItems()
    },
    // Monitor the variable listName and any time it changes value
    // Reload the data!
    [listName]
  )

  console.log(`We are looking at list ${listName}`)

  return (
    <div className="app">
      <header>
        <h1>One List</h1>
      </header>
      <main>
        <ul>
          <li>
            <button onClick={() => setListName('cohort42')}>Cohort 42</button>
          </li>
          <li>
            <button onClick={() => setListName('cohort-21')}>Cohort 21</button>
          </li>
          <li>
            <button onClick={() => setListName('illustriousvoyage')}>
              illustriousvoyage
            </button>
          </li>
        </ul>
        <ul>
          {todoItems.map(function (todoItem) {
            return (
              <li
                key={todoItem.id}
                className={todoItem.complete ? 'completed' : ''}
              >
                {todoItem.text}
              </li>
            )
          })}
        </ul>
        <form>
          <input
            type="text"
            placeholder="Whats up?"
            value={newTodoText}
            onChange={function (event) {
              setNewTodoText(event.target.value)
            }}
          />
        </form>
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

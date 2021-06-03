import axios from 'axios'
import React, { useEffect, useState } from 'react'
import logo from './images/sdg-logo.png'

function TodoItem(props) {
  const { id, complete, listName, reloadAfterChange } = props

  async function toggleCompleteStatus() {
    console.log('Clicked!')

    // The new status for completion is the opposite of the current status of completion
    const newCompleteStatus = !complete

    const response = await axios.put(
      `https://one-list-api.herokuapp.com/items/${id}?access_token=${listName}`,
      { item: { complete: newCompleteStatus } }
    )

    if (response.status === 200) {
      console.log(response.data)

      // Call whatever function I was given via the prop named "reloadAfterChange"
      reloadAfterChange()
    }
  }

  return (
    <li
      onClick={toggleCompleteStatus}
      className={props.complete ? 'completed' : ''}
    >
      {props.text}
    </li>
  )
}

export function App() {
  const [newTodoText, setNewTodoText] = useState('')
  const [listName, setListName] = useState('cohort42')
  const [todoItems, setTodoItems] = useState([])

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

  useEffect(
    function () {
      loadTheItems()
    },
    // Monitor the variable listName and any time it changes value
    // Reload the data!
    [listName]
  )

  async function handleCreateNewTodoItem(event) {
    // Please don't do your normal behavior
    // which would be to submit the form and reload the page
    event.preventDefault()

    console.log(`Creating a new todo with ${newTodoText}!`)
    const response = await axios.post(
      `https://one-list-api.herokuapp.com/items?access_token=${listName}`,
      {
        item: {
          text: newTodoText,
        },
      }
    )

    if (response.status === 201) {
      loadTheItems()
    }

    setNewTodoText('')
  }

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
              <TodoItem
                key={todoItem.id}
                listName={listName}
                reloadAfterChange={loadTheItems}
                id={todoItem.id}
                complete={todoItem.complete}
                text={todoItem.text}
              />
            )
          })}
        </ul>
        <form onSubmit={handleCreateNewTodoItem}>
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

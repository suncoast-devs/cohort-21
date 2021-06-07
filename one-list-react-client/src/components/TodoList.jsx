import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { TodoItem } from './TodoItem'

export function TodoList() {
  const [newTodoText, setNewTodoText] = useState('')
  const [listName, setListName] = useState(
    localStorage.getItem('list-name') || 'cohort42'
  )
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

  function handleChangeListName(newListName) {
    // Change the state
    setListName(newListName)

    // But also remember in the browser local storage
    // which list we are dealing with
    localStorage.setItem('list-name', newListName)
  }

  return (
    <>
      <ul>
        <li>
          <button onClick={() => handleChangeListName('cohort42')}>
            Cohort 42
          </button>
        </li>
        <li>
          <button onClick={() => handleChangeListName('cohort-21')}>
            Cohort 21
          </button>
        </li>
        <li>
          <button onClick={() => handleChangeListName('illustriousvoyage')}>
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
    </>
  )
}

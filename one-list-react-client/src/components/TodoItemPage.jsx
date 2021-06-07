import React, { useEffect, useState } from 'react'
import { useHistory, useParams } from 'react-router'
import axios from 'axios'
import { Link } from 'react-router-dom'

export function TodoItemPage() {
  const [todoItem, setTodoItem] = useState({
    id: undefined,
    text: '',
    complete: false,
    created_at: undefined,
    updated_at: undefined,
  })
  const { id } = useParams() // { id: 42 }        id variable = 42
  const history = useHistory()

  useEffect(
    function () {
      // Load the one item who's id is params.id
      async function loadOneItem() {
        const response = await axios.get(
          `https://one-list-api.herokuapp.com/items/${id}?access_token=cohort42`
        )

        if (response.status === 200) {
          setTodoItem(response.data)
        }
      }

      loadOneItem()
    },
    [id]
  )

  async function deleteTodoItem() {
    const response = await axios.delete(
      `https://one-list-api.herokuapp.com/items/${id}?access_token=cohort42`
    )

    if (response.status === 204) {
      // Redirect the user back to the home page!
      history.push('/')
    }
  }

  return (
    <div>
      <Link to="/">Go Home</Link>
      <p className={todoItem.complete ? 'completed' : ''}>{todoItem.text}</p>
      <p>Created: {todoItem.created_at}</p>
      <p>Updated: {todoItem.updated_at}</p>
      <button onClick={deleteTodoItem}>Delete</button>
    </div>
  )
}

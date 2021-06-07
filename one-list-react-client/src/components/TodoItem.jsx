import axios from 'axios'
import React from 'react'
import { Link } from 'react-router-dom'

//                destructuring from whatever the first argument is (e.g. what we used to call props)
//                |
//                |  props.id      props.listName
//                |  |             |
//                v  v             v
export function TodoItem({ id, complete, listName, reloadAfterChange, text }) {
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
    <li onClick={toggleCompleteStatus} className={complete ? 'completed' : ''}>
      {text}
      <Link to={`/items/${id}`}>(details)</Link>
    </li>
  )
}

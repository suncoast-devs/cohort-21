import React from 'react'

export function TodoItemList(props) {
  return props.todoItems.map(function (todoItem) {
    return (
      <li key={todoItem.id} className={todoItem.complete ? 'completed' : ''}>
        {todoItem.text}
      </li>
    )
  })
}

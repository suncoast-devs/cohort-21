import React from 'react'

// An example component to use below
function MyComponent({ name, children }) {
  return (
    <div>
      My name is {name} {children}
    </div>
  )
}

// Instead of writing JSX...

// export function App() {
//   return (
//     <MyComponent name="Gavin">
//       <h1>hello</h1>
//     </MyComponent>
//   )
// }

// We could write out the JavaScript long hand...
export function App() {
  return React.createElement(MyComponent, { name: 'Gavin' }, [
    React.createElement('h1', {}, 'hello'),
  ])
}

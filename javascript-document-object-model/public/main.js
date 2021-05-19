let currentPlayer = 'X'
let moveCounter = 0

function handleClickSquare(event) {
  const thingClickedOn = event.target

  if (thingClickedOn.nodeName !== 'LI') {
    console.log("You didn't click on an LI. Get outta here")
    return
  }

  if (thingClickedOn.classList.contains('taken')) {
    console.log('Nopes!')
    return
  }

  thingClickedOn.textContent = currentPlayer
  thingClickedOn.classList.add('taken')
  moveCounter++

  // Get the header to query for the first `h1`
  const header = document.querySelector('h1')

  // Interpolate a string with the header and the count of moves
  // and replace the text content of our header!

  //           C#:    $"Move {moveCounter of Tic Tac Toe"
  header.textContent = `Move ${moveCounter} of Tic Tac Toe`

  // If currentPlayer is precisely the text 'X', make the currentPlayer 'O'
  if (currentPlayer === 'X') {
    currentPlayer = 'O'
  } else {
    // Otherwise it was already 'O', so make it an 'X'
    currentPlayer = 'X'
  }
}

function main() {
  // Give us the very first `li` you can find.
  // Put a *REFERENCE* to that object (from the DOM)
  // in a variable called firstListItem
  // const firstListItem = document.querySelector('li')

  // // Change that object's textContent
  // firstListItem.textContent = 'X'

  // // Ensure the `taken` class is applied
  // // so that the cursor styling is present
  // firstListItem.classList.add('taken')

  //
  // What object
  //     |
  //     |        please listen for an event
  //     |            |
  //     |            |          name of event to wait for
  //     |            |             |
  //     |            |             |     function to call when it happens
  //     |            |             |        |
  //     v            v             v        v
  // firstListItem.addEventListener('click', handleClickSquare)

  // Finds *ALL* the `li` elements in the document
  // const allSquares = document.querySelectorAll('li')

  // // Loop through them
  // allSquares.forEach(function (square) {
  //   // For every element in allsquares, we'll call that `square`
  //   // and setup a listener. THE SAME FUNCTION WORKS!
  //   square.addEventListener('click', handleClickSquare)
  // })

  const gameBoard = document.querySelector('ul')
  gameBoard.addEventListener('click', handleClickSquare)
}

document.addEventListener('DOMContentLoaded', main)

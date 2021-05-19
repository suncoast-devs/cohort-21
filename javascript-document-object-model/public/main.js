function main() {
  // Give us the very first `li` you can find.
  // Put a *REFERENCE* to that object (from the DOM)
  // in a variable called firstListItem
  const firstListItem = document.querySelector('li')

  // Change that object's textContent
  firstListItem.textContent = 'X'
}

document.addEventListener('DOMContentLoaded', main)

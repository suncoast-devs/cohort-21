function main() {
  // Give us the very first `li` you can find.
  // Put a *REFERENCE* to that object (from the DOM)
  // in a variable called firstListItem
  const firstListItem = document.querySelector('li')

  // Change that object's textContent
  firstListItem.textContent = 'X'

  // Ensure the `taken` class is applied
  // so that the cursor styling is present
  firstListItem.classList.add('taken')
}

document.addEventListener('DOMContentLoaded', main)

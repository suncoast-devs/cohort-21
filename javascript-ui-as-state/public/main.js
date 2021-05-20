let counter = 0

function main() {
  const button = document.querySelector('button')

  button.addEventListener('click', function (event) {
    counter++

    const counterElement = document.querySelector('p')
    counterElement.textContent = counter
  })
}

document.addEventListener('DOMContentLoaded', main)

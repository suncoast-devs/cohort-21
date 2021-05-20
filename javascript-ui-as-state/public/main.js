let teamOneName = `Team 1`
let teamOneScore = 0

let teamTwoName = `Team 2`
let teamTwoScore = 0

function render() {
  const html = `
<header>
  <h1>My Score Board</h1>
</header>
<main>
  <section class="team1">
    <h2>${teamOneName}</h2>
    <h3>${teamOneScore}</h3>
    <fieldset>
      <input type="text" placeholder="Name" />
    </fieldset>

    <fieldset>
      <i class="add fas fa-2x fa-plus-circle"></i>
      <i class="subtract fas fa-2x fa-minus-circle"></i>
    </fieldset>
  </section>

  <section class="team2">
    <h2>${teamTwoName}</h2>
    <h3>${teamTwoScore}</h3>
    <fieldset>
      <input type="text" placeholder="Name" />
    </fieldset>

    <fieldset>
      <i class="add fas fa-2x fa-plus-circle"></i>
      <i class="subtract fas fa-2x fa-minus-circle"></i>
    </fieldset>
  </section>
</main>
  `

  document.body.innerHTML = html
}

function main() {
  render()
}

document.addEventListener('DOMContentLoaded', main)

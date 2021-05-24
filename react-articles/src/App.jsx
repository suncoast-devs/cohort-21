import React, { Component } from 'react'

export class App extends Component {
  render() {
    return (
      <div class="all-main-content">
        <main>
          <article class="intro-article">
            <h2 className="article-title">SDG Announces Hackathon!</h2>
            <p>
              SDG announces the 2020 Summer Hackathon. Join us for an exciting
              weekend
            </p>
            <a class="read-more" href="#here">
              read more about SDG Announces Hackathon!
            </a>
          </article>

          <article class="intro-article">
            <h2 className="article-title">
              Student Graduation is Right Around the Corner
            </h2>
            <p>
              Our next cohort of students will be graduating in just over a
              week.
            </p>
            <a class="read-more" href="#here">
              read more about Student Graduation is Right Around the Corner
            </a>
          </article>
        </main>
      </div>
    )
  }
}

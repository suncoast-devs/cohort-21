import React from 'react'

export class NewsArticle extends React.Component {
  render() {
    return (
      <article className="intro-article">
        <h2 className="article-title">{this.props.title}</h2>
        <p>{this.props.body}</p>
        <a className="read-more" href="#here">
          read more about {this.props.title}!
        </a>
      </article>
    )
  }
}

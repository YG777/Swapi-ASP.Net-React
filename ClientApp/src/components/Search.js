import React, { useState } from "react";

export const Search = () => {
    const [term, setTerm] = useState('');
    const [movies, setMovies] = useState([]);

    const onFormSubmit = async (term) => {
        const response = await fetch(`/api/movies?q=${term}`);
        setMovies(await response.json());
    }

    const onSubmit = (e) => {
        e.preventDefault()
        onFormSubmit(term)
    };

    const result = movies.map(movie => {
        return (
            <div>
                <h3>title: {movie.title}</h3>
                <h3>title: {movie.director}</h3>
                <h3>title: {movie.producer}</h3>
                <br/>
            </div>
            )
    })

    return (
        <div>
            <form onSubmit={onSubmit}>
                <label>Search</label>
                <input
                    type="text"
                    value={term}
                    onChange={(e) => setTerm(e.target.value)}
                >
                </input>
            </form>

            <div>
                <p>search input: {term}</p>
                <p>Movies : {movies.length}</p>
                <div>{result}</div>
            </div>

        </div>
    );
}


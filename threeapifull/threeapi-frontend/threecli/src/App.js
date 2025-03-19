import React from 'react';
import CryptoData from '../src/components/cryptoData.js';
import CovidData from '../src/components/covidData.js';
import MovieData from '../src/components/movieData.js';

function App() {
    return (
        <div className="container mx-auto p-8">
            <h1 className="text-4xl font-bold text-center mb-8">ThreeAPI Full Stack App</h1>
            <CryptoData />
            <CovidData />
            <MovieData />
        </div>
    );
}

export default App;

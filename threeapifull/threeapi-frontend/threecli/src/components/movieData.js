import React, { useState } from 'react';
import { fetchMovieData } from '../services/apiservice';

const MovieData = () => {
    const [title, setTitle] = useState('');
    const [data, setData] = useState(null);

    const handleFetchData = async () => {
        try {
            const result = await fetchMovieData(title);
            setData(result);
        } catch (error) {
            console.error('Error fetching movie data:', error);
        }
    };

    return (
        <div className="bg-white shadow-md rounded-lg p-6 mb-6">
            <h2 className="text-2xl font-bold mb-4">Movie Data</h2>
            <input
                type="text"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                placeholder="Enter Movie Title"
                className="border border-gray-300 rounded-lg p-2 w-full mb-4"
            />
            <button
                onClick={handleFetchData}
                className="bg-red-500 text-white py-2 px-4 rounded-lg hover:bg-red-600"
            >
                Fetch Data
            </button>
            {data && (
                <div className="mt-4">
                    <h3 className="text-xl font-semibold">{data.title}</h3>
                    <p className="text-gray-600">Year: {data.year}</p>
                    <p className="text-gray-600">Genre: {data.genre}</p>
                    <p className="text-gray-600">Director: {data.director}</p>
                    <p className="text-gray-600">Plot: {data.plot}</p>
                </div>
            )}
        </div>
    );
};

export default MovieData;

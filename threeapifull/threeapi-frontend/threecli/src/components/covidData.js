import React, { useState } from 'react';
import { fetchCovidData } from '../services/apiservice'

const CovidData = () => {
    const [country, setCountry] = useState('');
    const [data, setData] = useState(null);

    const handleFetchData = async () => {
        try {
            const result = await fetchCovidData(country);
            setData(result);
            console.log(result);
        } catch (error) {
            console.error('Error fetching COVID data:', error);
        }
    };

    return (
        <div className="bg-white shadow-md rounded-lg p-6 mb-6">
            <h2 className="text-2xl font-bold mb-4">COVID Data</h2>
            <input
                type="text"
                value={country}
                onChange={(e) => setCountry(e.target.value)}
                placeholder="Enter Country (e.g., usa)"
                className="border border-gray-300 rounded-lg p-2 w-full mb-4"
            />
            <button
                onClick={handleFetchData}
                className="bg-green-500 text-white py-2 px-4 rounded-lg hover:bg-green-600"
            >
                Fetch Data
            </button>
            {data && (
                <div className="mt-4">
                    <h3 className="text-xl font-semibold">{data.country}</h3>
                    <p className="text-gray-600">Cases: {data.cases}</p>
                    <p className="text-gray-600">Deaths: {data.deaths}</p>
                    <p className="text-gray-600">Active: {data.active}</p>
                    <p className="text-gray-600">Recovered: {data.recovered}</p>
                </div>
            )}
        </div>
    );
};

export default CovidData;

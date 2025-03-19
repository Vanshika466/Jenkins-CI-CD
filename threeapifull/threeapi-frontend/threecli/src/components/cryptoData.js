import React, { useState } from 'react';
import { fetchCryptoData } from '../services/apiservice';

const CryptoData = () => {
    const [cryptoId, setCryptoId] = useState('');
    const [data, setData] = useState(null);

    const handleFetchData = async () => {
        try {
            const result = await fetchCryptoData(cryptoId);
            setData(result);
        } catch (error) {
            console.error('Error fetching crypto data:', error);
        }
    };

    return (
        <div className="bg-white shadow-md rounded-lg p-6 mb-6">
            <h2 className="text-2xl font-bold mb-4">Crypto Data</h2>
            <input
                type="text"
                value={cryptoId}
                onChange={(e) => setCryptoId(e.target.value)}
                placeholder="Enter Crypto ID (e.g., bitcoin)"
                className="border border-gray-300 rounded-lg p-2 w-full mb-4"
            />
            <button
                onClick={handleFetchData}
                className="bg-blue-500 text-white py-2 px-4 rounded-lg hover:bg-blue-600"
            >
                Fetch Data
            </button>
            {data && (
                <div className="mt-4">
                    <h3 className="text-xl font-semibold">{data.crypto}</h3>
                    <p className="text-gray-600">Price (USD): ${data.price}</p>
                </div>
            )}
        </div>
    );
};

export default CryptoData;

import axios from 'axios';

const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

export const fetchCryptoData = async (cryptoId) => {
    const response = await axios.get(`${API_BASE_URL}/crypto/${cryptoId}`);
    return response.data;
};

export const fetchCovidData = async (country) => {
    const response = await axios.get(`${API_BASE_URL}/covid/${country}`);
    return response.data;
};

export const fetchMovieData = async (title) => {
    const response = await axios.get(`${API_BASE_URL}/movie/${title}`);
    return response.data;
};

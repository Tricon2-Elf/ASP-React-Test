import { useState } from 'react';
import './App.css';

function App() {
    //States for users name, ressult demographic data, and for displaying a loading screen
    const [name, setName] = useState('');
    const [demographicData, setDemographicData] = useState();
    const [loading, setLoading] = useState(false);

    //Set contents to either Loading, Starting message or returned demographic data from the API
    const contents = loading ? (
        <p><em>Loading...</em></p>
    ) : demographicData === undefined ? (
        <p><em>Enter a name and press Estimate</em></p>
    ) : (
        <div>
            Gender: {demographicData.gender}<br />
            Age: {demographicData.age}<br />
            Country: {demographicData.country_name}
        </div>
    );

    return (
        <div>
            <h1>Predict Age, Gender and Ethnicity</h1>
            <p>This website uses <a href="https://nationalize.io">nationalize.io</a>, <a href="https://genderize.io">genderize.io</a> and <a href="https://agify.io">agify.io</a> to estimate the name, gender and ethnicity of the entered name</p>
            <input
                type="text"
                value={name}
                onChange={e => setName(e.target.value)}
                placeholder="Enter Name"
            />
            <button onClick={populateDemographicData}>Estimate</button>
            {contents}
        </div>
    );
    
    async function populateDemographicData() {
        setLoading(true);
        //Clear demographic data so that it will display the 'loading' message
        setDemographicData(undefined);
        try {
            const response = await fetch(`allify?name=${encodeURIComponent(name)}`);
            if (response.ok) {
                //Get json response from the /allify path
                const data = await response.json();
                if (data.age === 0) data.age = "Not in dataset";
                if (data.gender === "") data.gender = "Not in dataset";
                if (data.country_name === "") data.country_name = "Not in dataset";
                setDemographicData(data);
            }
        } finally {
            setLoading(false);
        }
    }
}

export default App;
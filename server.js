const express = require('express');
const mysql = require('mysql2');

const app = express();

app.use(express.json());

const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'Beachresortsystem_db'
});

db.connect((err) => {
    if (err) {
        console.log('Database connection failed:', err);
        return;
    }

    console.log('Connected to MySQL');
});

app.get('/', (req, res) => {
    res.send('Beach Resort API is running');
});

app.get('/rooms', (req, res) => {

    db.query(
      'SELECT * FROM rooms',
      (err, results) => {

        if(err){
           res.status(500).send(err);
           return;
        }

        res.json(results);

      }
    );

});

app.listen(3000, () => {
    console.log('Server running on port 3000');
});
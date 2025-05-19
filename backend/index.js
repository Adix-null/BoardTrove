require("dotenv").config(); // Load env variables first

const express = require("express");
const cors = require("cors");
const { Pool } = require('pg');

// Create a pool using your connection string
const pool = new Pool({ connectionString: process.env.DATABASE_URL });

const app = express();
const PORT = process.env.PORT || 3000;

app.use(cors());
app.use(express.json());

app.get("/users", async (req, res) => {
    try {
        const users = await pool.query('SELECT id, email FROM users WHERE id=\'1\'');
        res.json(users.rows);
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
});

app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`);
})

app.get("/", (req, res) => {
    res.send("hello backend");
})

app.get("/user", (req, res) => {
    res.status(200).send(
        {
            name: "Garry Kasparov",
            rating: 2850
        });
});

app.post("/game/:id", (req, res) => {
    const { id } = req.params;
    const { pgn } = req.body;

    if (!pgn) {
        res.status(406).send({ message: "PGN not found" });
    }

    res.send({
        game: `Game no.${id} = ${pgn}`
    });

    //INSERT INTO
});
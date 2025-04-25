const express = require("express");
const cors = require("cors");
require("dotenv").config();

const app = express();
const PORT = process.env.PORT || 3000;

//app.use(cors());
app.use(express.json());

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
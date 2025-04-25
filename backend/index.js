const express = require("express")
const cors = require("cors")
require("dotenv").config()

const app = express()
const PORT = process.env.PORT || 3000

app.use(cors())

app.get("/", (req, res) => {
    res.send("Hello from backend!")
})

app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`)
})

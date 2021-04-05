
const express = require('express')
const app = express()
const fetch = require('node-fetch')
const port = 80 || process.env.PORT

app.get('/routes', (req, res) => {
  fetch('http://booking-ng-providers-service/routes')
    .then(res => res.json())
    .then(json => res.send(json))
})

app.listen(port, () => {
  console.log(`App listening at http://localhost:${port}`)
})

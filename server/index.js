const app = require('express')();
const port = process.env.PORT || 8080;
const fs = require('fs');

const data = require('./response.json');

app.get('/', (req, res) => {
  console.log(data);
  console.log(req);
  res.json(data);
});

app.listen(port, () => console.log(`server up on ${port}`));

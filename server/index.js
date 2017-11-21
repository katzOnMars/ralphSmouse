const app = require('express')();
const port = process.env.PORT || 8080;
const fs = require('fs');

const data = fs.readFileSync('./response.json');

app.get('/', (req, res) => {
  console.log(JSON.parse(data));
  res.json(JSON.parse(data))
});

app.listen(port, () => console.log(`server up on ${port}`));

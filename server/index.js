const app = require('express')();
const port = process.env.PORT || 8080;

app.get('/', (req, res) => {
  console.log(req);
  res.json('hey')
});

app.listen(port, () => console.log(`server up on ${port}`));

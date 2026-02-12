self.onmessage = function (e) {
  let n = e.data;
  let sum = 0;

  for (let i = 1; i <= n; i++) {
    sum += i;
  }

  self.postMessage(sum);
};

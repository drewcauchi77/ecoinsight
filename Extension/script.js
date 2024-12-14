document.addEventListener("DOMContentLoaded", function () {
  const rand = document.querySelector(".rand");

  chrome.storage.local.get(["rN"]).then((res) => {
    const valueFromStorage = res.rN;

    if (valueFromStorage) {
      if (rand) rand.textContent = valueFromStorage;
    } else {
      const randomNumber = Math.ceil(Math.random() * 100);

      chrome.storage.local.set({ rN: randomNumber }).then(() => {
        console.log(`Key - rN : Value - ${randomNumber}`);
      });

      if (rand) rand.textContent = valueFromStorage;
    }
  });
});

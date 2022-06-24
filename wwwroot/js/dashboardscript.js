const rainDiv = document.querySelector(".rain-div");

// background Colors for the raindrop
const background = [
    "linear-gradient(transparent, aquamarine)",
    "linear-gradient(transparent, orange)",
    "linear-gradient(transparent, yellowgreen)",
    "linear-gradient(transparent, white)",
    "linear-gradient(transparent, blueviolet)"
];

const amount = 65; // amount of raindops
let drop, raindropProperties;

// Looping and creating the raindrop then adding to the rainDiv
for (let i = 0; i < amount; i++) {
    drop = document.createElement("i");

    //   CSS Properties for raindrop
    raindropProperties = {
        width: Math.random() * 5 + "px",
        positionX: Math.floor(Math.random() * window.innerWidth) + "px",
        delay: Math.random() * -7 + "s",
        duration: Math.random() * 25 + 1 + "s",
        bg: background[Math.floor(Math.random() * background.length)],
        opacity: Math.random() + 0.2
    };

    //   Setting Styles for raindrop
    drop.style.width = raindropProperties.width;
    drop.style.left = raindropProperties.positionX;
    drop.style.animationDelay = raindropProperties.delay;
    drop.style.animationDuration = raindropProperties.duration;
    drop.style.background = raindropProperties.bg;
    drop.style.opacity = raindropProperties.opacity;

    //   Appending the raindrop in the raindrop container
    rainDiv.appendChild(drop);
}
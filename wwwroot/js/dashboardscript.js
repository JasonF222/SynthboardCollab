const rainContainer = document.querySelector(".rain-container");

// background Colors for the raindrop
const background = [
    "linear-gradient(transparent, aquamarine)",
    "linear-gradient(transparent, orange)",
    "linear-gradient(transparent, yellowgreen)",
    "linear-gradient(transparent, white)",
    "linear-gradient(transparent, blueviolet)"
];

const amount = 45; // amount of raindops
let i = 0;
let drop, raindropProperties;


while (i < amount) {
    drop = document.createElement("i");

    //   Raindrop CSS properties //
    raindropProperties = {
        width: Math.random() * 5 + "px",
        positionX: Math.floor(Math.random() * window.innerWidth) + "px",
        delay: Math.random() * -20 + "s",
        duration: Math.random() * 5 + "s",
        bg: background[Math.floor(Math.random() * background.length)],
        opacity: Math.random() + 0.2
    };

    //   Raindrop styling //
    drop.style.width = raindropProperties.width;
    drop.style.left = raindropProperties.positionX;
    drop.style.animationDelay = raindropProperties.delay;
    drop.style.animationDuration = raindropProperties.duration;
    drop.style.background = raindropProperties.bg;
    drop.style.opacity = raindropProperties.opacity;

    //   Raindrop into rainContainer //
    rainContainer.appendChild(drop);
    i++;
}
const images = [
    'images/images2.png', 'images/images4.png'
];
let currentIndex = 0;//start with the first image

function changeImage() {
    currentIndex++;
    if (currentIndex >= images.length) {
        currentIndex = 0;
    }
    document.getElementById('dynamicImage').src = images[currentIndex];
}
setInterval(changeImage, 5000);

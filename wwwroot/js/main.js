// Функции для обработки нажатия кнопок
function navigate() {
console.log("Кнопка навигации нажата");
// Здесь можно добавлять логику навигации
}

function buttonClicked() {
console.log("Основная кнопка нажата");
}

function profile() {
const menu = document.getElementById("profileMenu");
menu.style.display = "block"; // Показываем меню
}

function closeProfileMenu() {
const menu = document.getElementById("profileMenu");
menu.style.display = "none"; // Скрываем меню
}

function copyReferralLink() {
    const referralLink = "https://your-referral-link.com"; // Replace with your actual referral link
    navigator.clipboard.writeText(referralLink).then(() => {
        alert("Referral link copied to clipboard!");
    }).catch(err => {
        console.error("Failed to copy: ", err);
    });
}

function toggleMyPlanetMenu() {
    const menu = document.getElementById('myPlanetMenu');
    if (menu.style.display === 'none' || menu.style.display === '') {
        menu.style.display = 'block'; // Show the menu
    } else {
        menu.style.display = 'none'; // Hide the menu
    }
}

function closeMyPlanetMenu() {
    document.getElementById('myPlanetMenu').style.display = 'none'; // Hide the menu
}

// Example functions for menu options
function option1() {
    alert("You clicked Option 1!");
}

function option2() {
    alert("You clicked Option 2!");
}

// Инициализация сцены, камеры и рендерера
const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

// Загрузка текстуры для фона
const backgroundTexture = new THREE.TextureLoader().load('images/16T.jpg'); // Укажите путь к вашей текстуре фона

// Создание сферы фона
const backgroundSphereGeometry = new THREE.SphereGeometry(30, 35, 35);
const backgroundSphereMaterial = new THREE.MeshBasicMaterial({ map: backgroundTexture, side: THREE.BackSide });
const backgroundSphere = new THREE.Mesh(backgroundSphereGeometry, backgroundSphereMaterial);
scene.add(backgroundSphere);

// Загрузка текстуры для ядра
const textureLoader = new THREE.TextureLoader();
const coreTexture = textureLoader.load('images/fffaaa.jpg');

// Создание геометрии и материала для ядра
const coreGeometry = new THREE.SphereGeometry(0.5, 32, 32);
const coreMaterial = new THREE.MeshBasicMaterial({ map: coreTexture });
const core = new THREE.Mesh(coreGeometry, coreMaterial);
scene.add(core); 

// Создание системы частиц
const particlesCount = 1000;
const particles = new THREE.BufferGeometry();
const positions = new Float32Array(particlesCount * 3);
const colors = new Float32Array(particlesCount * 3);

for (let i = 0; i < particlesCount; i++) {
positions[i * 3] = (Math.random() - 0.5) * 100;
positions[i * 3 + 1] = (Math.random() - 0.5) * 100;
positions[i * 3 + 2] = (Math.random() - 0.5) * 100;
const color = new THREE.Color(Math.random(), Math.random(), Math.random());
colors[i * 3] = color.r;
colors[i * 3 + 1] = color.g;
colors[i * 3 + 2] = color.b;
}

particles.setAttribute('position', new THREE.BufferAttribute(positions, 3));
particles.setAttribute('color', new THREE.BufferAttribute(colors, 3));

const particleMaterial = new THREE.PointsMaterial({ size: 0.03, vertexColors: true });
const particleSystem = new THREE.Points(particles, particleMaterial);
scene.add(particleSystem);

// Параметры управления камерой
let isMouseDown = false;
let previousMousePosition = { x: 0, y: 0 };
let theta = 0;
let phi = 0;
let radius = 5;

// Создание текстовых объектов
const textLoader = new THREE.FontLoader();
const texts = [];
const textCount = 10;
const textDistances = [];
const randomAngles = [];

textLoader.load('https://threejs.org/examples/fonts/helvetiker_regular.typeface.json', (font) => {
for (let i = 0; i < textCount; i++) {
const textGeometry = new THREE.TextGeometry(Math.random() < 0.5 ? '0' : '1', {
font: font,
size: 0.2,
height: 0.05,
});
const textMaterial = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
const textMesh = new THREE.Mesh(textGeometry, textMaterial);

const distanceFromCore = 1.5 + (i * 0.1);
const angle = (i % 2 === 0 ?  1 : -1) * Math.random() * Math.PI * 2;
textMesh.position.set(distanceFromCore * Math.cos(angle), 0, distanceFromCore * Math.sin(angle));
scene.add(textMesh);
texts.push(textMesh);
textDistances.push(distanceFromCore);
randomAngles.push(angle);
}
});

// Обработчики событий мыши
window.addEventListener('mousedown', (event) => {
isMouseDown = true;
previousMousePosition = { x: event.clientX, y: event.clientY };
});

window.addEventListener('mouseup', () => {
    isMouseDown = false;
});

window.addEventListener('mousemove', (event) => {
if (!isMouseDown) return;

const deltaMove = {
x: event.clientX - previousMousePosition.x,
y: event.clientY - previousMousePosition.y,
};

theta -= deltaMove.x * 0.001;
phi -= deltaMove.y * 0.001;
phi = Math.max(-Math.PI / 2, Math.min(Math.PI / 2, phi));

const x = radius * Math.cos(phi) * Math.sin(theta);
const y = radius * Math.sin(phi);
const z = radius * Math.cos(phi) * Math.cos(theta);
camera.position.set(x, y, z);
camera.lookAt(core.position);

previousMousePosition = { x: event.clientX, y: event.clientY };
});

// Обработчики событий касания для мобильных устройств
window.addEventListener('touchstart', (event) => {
isMouseDown = true;
previousMousePosition = { x: event.touches[0].clientX, y: event.touches[0].clientY };
});

window.addEventListener('touchend', () => {
isMouseDown = false;
});

window.addEventListener('touchmove', (event) => {
if (!isMouseDown) return;

const deltaMove = {
x: event.touches[0].clientX - previousMousePosition.x,
y: event.touches[0].clientY - previousMousePosition.y,
};

theta -= deltaMove.x * 0.01;
phi -= deltaMove.y * 0.01;
phi = Math.max(-Math.PI / 2, Math.min(Math.PI / 2, phi));

const x = radius * Math.cos(phi) * Math.sin(theta);
const y = radius * Math.sin(phi);
const z = radius * Math.cos(phi) * Math.cos(theta);
camera.position.set(x, y, z);
camera.lookAt(core.position);

previousMousePosition = { x: event.touches[0].clientX, y: event.touches[0].clientY };
});

// Максимальное расстояние для камеры
const maxRadius = 15; // Установите максимальное значение по вашему усмотрению

// Обработка прокрутки для зума
window.addEventListener('wheel', (event) => {
radius += event.deltaY * 0.01;
radius = Math.max(2, Math.min(maxRadius, radius)); // Ограничиваем radius
const x = radius * Math.cos(phi) * Math.sin(theta);
const y = radius * Math.sin(phi);
const z = radius * Math.cos(phi) * Math.cos(theta);
camera.position.set(x, y, z);
camera.lookAt(core.position);
});

// Функция для обновления позиций частиц
function updateParticlePositions() {
const positions = particleSystem.geometry.attributes.position.array;

for (let i = 0; i < particlesCount; i++) {
const index = i * 3;
const x = positions[index];
const y = positions[index + 1];
const z = positions[index + 2];

const direction = new THREE.Vector3(core.position.x - x, core.position.y - y, core.position.z - z).normalize();
const speed = 0.009;

positions[index] += direction.x * speed;
positions[index + 1] += direction.y * speed;
positions[index + 2] += direction.z * speed;

if (Math.sqrt(positions[index] ** 2 + positions[index + 1] ** 2 + positions[index + 2] ** 2) < 0.5) {
positions[index] = (Math.random() - 0.5) * 20;
positions[index + 1] = (Math.random() - 0.5) * 20;
positions[index + 2] = (Math.random() - 0.5) * 20;
}
}
particleSystem.geometry.attributes.position.needsUpdate = true;
}

// Функция для обновления позиции камеры
function updateCameraPosition() {
const x = radius * Math.cos(phi) * Math.sin(theta);
const y = radius * Math.sin(phi);
const z = radius * Math.cos(phi) * Math.cos(theta);
camera.position.set(x, y, z);
camera.lookAt(core.position);
}

// Функция для обновления позиций текстов
function updateTextPositions() {
const rotationSpeed = 0.01;
texts.forEach((textMesh, index) => {
randomAngles[index] += rotationSpeed;
const distanceFromCore = textDistances[index];
const angleOffset = (index % 2 === 0 ? 1 : -1) * randomAngles[index];
textMesh.position.set(
distanceFromCore * Math.cos(angleOffset),
0,
distanceFromCore * Math.sin(angleOffset)
);
});
}

// Анимация
function animate() {
requestAnimationFrame( animate);
updateParticlePositions(); // Обновляем позиции частиц
updateCameraPosition();
updateTextPositions(); // Обновляем позиции текстов
renderer.render(scene, camera);
}

animate();

// Обработка изменения размеров окна
window.addEventListener('resize', () => {
camera.aspect = window.innerWidth / window.innerHeight;
camera.updateProjectionMatrix();
renderer.setSize(window.innerWidth, window.innerHeight);
});
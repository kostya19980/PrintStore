var TextureBaseUrl = "";
var type = "";
$(document).ready(function () {
    var hide = false;
    $("#hide_scene").click(function () {
        if (hide == false) {
            $(".reload_scene").css({ "display": "none" });
            $(".ModelViewer>div>button").text("Развернуть");
            $(".ModelViewer").css({
                "top": "18px",
                "left": "-12px",
                "transform": "rotate(90deg)",
                "height": "0px",
                "width": "57px"
            })
            $(".ModelViewer>canvas").css({
                "height": "0px",
            })
            hide = true;
        }
        else {
            $(".reload_scene").css({ "display": "block" });
            $(".ModelViewer>div>button").text("Свернуть");
            $(".ModelViewer").css({
                "top": "-18px",
                "left": "12px",
                "transform": "rotate(0deg)",
                "height": "400px",
                "width": "300px"
            })
            $(".ModelViewer>canvas").css({
                "height": "400px",
            })
            hide = false;
        }
    })
    $(".reload_scene").click(function () {
        realtimeChangeTexture();
    })
})
class Product3D {
    constructor(container) {
        this.container = container;
        var width = $(container).width();
        var height = $(container).height();
        this.camera = new THREE.PerspectiveCamera(45, width / height, 0.1, 1000000);
        this.setCameraDefaultPosition();
        this.scene = new THREE.Scene();
        this.renderer = new THREE.WebGLRenderer({
            preserveDrawingBuffer: true,
            antialias: true
        });
        this.renderer.setClearColor(0x20222D);
        this.renderer.setSize(width, height);
        container.appendChild(this.renderer.domElement);
        this.controls = new THREE.OrbitControls(this.camera, this.renderer.domElement);
        this.controls.enableDamping = true;
        this.controls.dampingFactor = 0.25;
        this.controls.enableZoom = true;
        this.controls.enableRotate = true;
        this.controls.enablePan = true;
        this.objLoader = new THREE.OBJLoader();
        this.imageLoader = new THREE.ImageLoader();
        this.animate();
        this.light();
    };
    setCameraDefaultPosition() {
        this.camera.position.z = 4000;
        this.camera.position.x = -4000;
        this.camera.position.y = 4000;
    };
    light() {
    const ambient = new THREE.AmbientLight(0xffffff, 0.7);
    this.scene.add(ambient);

    const directionalLight = new THREE.DirectionalLight(0xffffff);
    directionalLight.position.set(0, 1, 1);
    this.scene.add(directionalLight);
}
    animate() {
        requestAnimationFrame(this.animate.bind(this));
        this.renderer.render(this.scene, this.camera);
    };
    resizeView() {
        var width = $(this.container).width();
        var height = $(this.container).height();
        this.renderer.setSize(width.height);
        this.camera.aspect = width / height;
        this.camera.updateProjectionMatrix();
    }
    addProduct(model, texturePath) {
        var texture = new THREE.Texture();
        var scene = this.scene;
        this.imageLoader.load(texturePath, (image) => {
            texture.image = image;
            texture.needsUpdate = true;
        });
        this.objLoader.load(model, function (obj) {
            obj.scale.set(700, 700, 700);
            obj.name = "cup";
            scene.add(obj);
            scene.getObjectByName("cup").children[0].material.map = texture;
        })
    }
    changeProductTexture(name, img) {
        var texture = new THREE.Texture();
        this.imageLoader.load(img.src, (image) => {
            texture.image = image;
            texture.needsUpdate = true;
        });
        this.scene.getObjectByName(name).children[0].material.map=texture;
    }
}
function realtimeChangeTexture() {
    var tempScale = scale;
    if (scale != 1) {
        scale = 1;
        $(".template").css({ "transition-duration": ".0s", "transform": "scale(1)" });
    }
    var img1 = new Image();
    var img2 = new Image();
    img1.src = TexturePath;
    html2canvas(document.querySelector('.template'), {
        scrollY: -window.scrollY,
        scale: 1
    })
        .then(function (canvas) {
            img2.src = canvas.toDataURL();
            img2.onload = function () {
                var c = document.createElement("canvas");
                var ctx = c.getContext("2d");
                c.width = img1.width;
                c.height = img1.height;
                ctx.drawImage(img1, 0, 0);
                var x = TextureAreaLeft + img2.height;
                var y = TextureAreaTop;
                ctx.translate(x, y);
                ctx.rotate(90 * Math.PI / 180);
                ctx.drawImage(img2, 0, 0, img2.width, img2.height);
                var resultImg = new Image();
                resultImg.src = c.toDataURL();
                resultImg.onload = function () {
                    TextureBaseUrl = resultImg.src.replace(/^data:image\/[a-z]+;base64,/, "");
                    product.changeProductTexture("cup", resultImg);
                    SaveTemplate();
                }
                //saveAs(c.toDataURL(), 'file-name.png');
            }
            scale = tempScale;
            $(".template").css({ "transition-duration": ".0s", "transform": "scale(" + scale + ")" });
        });
}
function saveAs(uri, filename) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
        link.href = uri;
        link.download = filename;
        //Firefox requires the link to be in the body
        document.body.appendChild(link);
        //simulate click
        link.click();
        //remove the link when done
        document.body.removeChild(link);
    } else {
        window.open(uri);
    }
}
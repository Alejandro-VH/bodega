INSERT INTO productos (nombre, precio, unidad_medida) VALUES
('Arroz Grado 1', 1200, 'kg'),
('Azúcar Rubia', 1150, 'kg'),
('Aceite Vegetal', 2500, 'lt'),
('Leche Entera', 1100, 'lt'),
('Fideos Spaghetti', 950, 'kg'),
('Cereal de Avena', 1800, 'caja'),
('Café Instantáneo', 2900, 'frasco'),
('Harina de Trigo', 900, 'kg'),
('Sal yodada', 700, 'kg'),
('Atún en Agua', 1500, 'lata');

INSERT INTO bodegas (nombre) VALUES
('Bodega Central'),
('Bodega Norte'),
('Bodega Sur');

INSERT INTO producto_bodega (id_producto, id_bodega, cantidad) VALUES
(1, 1, 500),
(1, 2, 200),
(2, 1, 400),
(2, 3, 100),
(3, 1, 150),
(3, 2, 100),
(4, 3, 300),
(5, 1, 250),
(6, 1, 75),
(6, 2, 40),
(7, 2, 30),
(8, 3, 120),
(9, 1, 90),
(10, 2, 200);
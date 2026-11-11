# Reparaciones RAW

Aplicación de consola en C# para gestionar el día a día de **Reparaciones RAW**, un pequeño taller de reparación de móviles. Permite registrar una reparación, cobrarla, mostrar el ticket y consultar la caja del día.

Proyecto de la UT2 (*Iniciación a la programación*, SMR2 · Diseño de algoritmos).

- **Autor:** Alejandro Román
- **Repositorio:** https://github.com/RmnXL/ProyectoUT2

## Cómo ejecutarlo

Requisitos: [.NET SDK 10](https://dotnet.microsoft.com/download) (el proyecto apunta a `net10.0`).

```bash
git clone https://github.com/RmnXL/ProyectoUT2.git
cd ProyectoUT2
dotnet run
```

Toda la lógica está en un único archivo, `Program.cs`, con instrucciones de nivel superior. No usa arrays, listas, ficheros ni bases de datos: los datos de la sesión se pierden al cerrar el programa.

## Menú principal

| Opción | Acción |
|---|---|
| 1 | Empezar un pedido (nueva reparación) |
| 2 | Pedidos del día (caja y estadísticas) |
| 0 | Salir (despedida y resumen de pedidos e ingresos) |

El menú se repite hasta elegir `0`; una opción incorrecta muestra un aviso y permite volver a intentarlo.

## Servicios, extras y condición específica

**Reparación principal** (se elige una por pedido):

| Opción | Precio |
|---|---|
| Cambiar pantalla | 60 € |
| Cambiar batería | 40 € |
| Limpieza y revisión general | 25 € |

**Extras** (menú repetitivo hasta pulsar `0`; se puede terminar sin extras; se admiten varias unidades del mismo extra):

| Extra | Precio por unidad |
|---|---|
| Protector de pantalla | 8 € |
| Copia de seguridad de los datos | 10 € |
| Funda | 12 € |

**Condición específica:** reparación **normal** o **urgente** (en el día). La urgente suma un recargo de **15 €** y pide un teléfono de contacto obligatorio (no puede estar vacío ni solo con espacios); la normal no pide ningún dato adicional.

## Regla de descuento y fórmula

```
subtotal  = precio de la reparación + recargo urgente (si procede) + extras
descuento = 10 % del subtotal, solo si subtotal >= 100 €  (si no, 0 €)
total     = subtotal - descuento
cambio    = importe entregado - total
```

El descuento se aplica sobre todo el subtotal, incluido el recargo urgente y los extras. Si el importe entregado no alcanza el total, se pide de nuevo hasta que sea suficiente. La operación se contabiliza una sola vez, cuando el pago es correcto.

## Caja del día

Muestra el número de pedidos cobrados, la recaudación (suma de los totales finales, no del dinero entregado), el importe medio, el pedido más caro y el nombre de su cliente. Si hay empate en el máximo se conserva el primero. Sin pedidos, muestra un aviso y no divide entre cero.

## Fases del programa

1. **Menú principal** (bucle `do...while`) y variables de la sesión: nº de pedidos, recaudación y pedido más caro.
2. **Datos del cliente:** nombre obligatorio (se repite la petición si está vacío o solo tiene espacios).
3. **Reparación principal:** selección validada con bucle y asignación del precio.
4. **Condición específica:** normal o urgente (la urgente pide teléfono).
5. **Extras:** menú repetitivo con un contador de unidades por extra.
6. **Importe y descuento:** subtotal y regla del 10 %.
7. **Cobro:** bucle hasta que el pago sea suficiente y cálculo del cambio.
8. **Caja:** actualización de las estadísticas de la sesión.
9. **Ticket** y consulta/cierre de la caja.
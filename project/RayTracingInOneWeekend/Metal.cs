﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Metal : Material
    {
        Vector3 albedo;
        float fuzz;
        public Metal(Vector3 _albedo, float f = 0) { this.albedo = _albedo; if (f < 1) fuzz = f; else fuzz = 1; }
        public bool scatter(Ray r, HitRecord rec, ref Vector3 attattenuation, ref Ray scattered)
        {
            Vector3 reflected = Vector3.reflect(r.direction().normalized, rec.normal);
            scattered = new Ray(rec.p, reflected + fuzz * Sphere.random_in_unit_sphere());
            attattenuation = albedo;
            return Vector3.dot(reflected, rec.normal) > 0;
        }
    }
}

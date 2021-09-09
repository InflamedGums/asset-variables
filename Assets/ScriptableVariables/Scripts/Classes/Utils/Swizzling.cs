using UnityEngine;

namespace InflamedGums.Util.Types
{
    public struct Float2
    {
        private Vector2 m_Value;

        public static implicit operator Float2(Vector2 v)
            => new Float2 { m_Value = v };

        public static implicit operator Vector2(Float2 v)
            => v.m_Value;

        public Float2(float x)
            => m_Value = new Vector2(x, 0);
        public Float2(float x, float y)
        => m_Value = new Vector2(x, y);
        public Float2(Float2 xy)
            => m_Value = xy;

        // Swizzling
        public float x
        {
            get => m_Value.x;
            set => m_Value.x = value;
        }
        public float y
        {
            get => m_Value.y;
            set => m_Value.y = value;
        }
        public Float2 xy
        {
            get => new Vector2(m_Value.x, m_Value.y);
            set => m_Value = new Vector2(value.x, value.y);
        }

        public Float2 yx
        {
            get => new Vector2(m_Value.y, m_Value.x);
            set => m_Value = new Vector2(value.y, value.x);
        }
    }


    public struct Float3
    {
        private Vector3 m_Value;

        public static implicit operator Float3(Vector3 v)
            => new Float3 { m_Value = v };

        public static implicit operator Vector3(Float3 v)
            => v.m_Value;

        public Float3(float x)
            => m_Value = new Vector3(x, 0, 0);
        public Float3(float x, float y)
        => m_Value = new Vector3(x, y, 0);
        public Float3(float x, float y, float z)
            => m_Value = new Vector3(x, y, z);
        public Float3(Float2 xy, float z)
            => m_Value = new Vector3(xy.x, xy.y, z);
        public Float3(float x, Float2 yz)
        => m_Value = new Vector3(x, yz.x, yz.y);
        public Float3(Float3 xyz)
            => m_Value = xyz;

        // Swizzling
        public float x
        {
            get => m_Value.x;
            set => m_Value.x = value;
        }
        public float y
        {
            get => m_Value.y;
            set => m_Value.y = value;
        }
        public float z
        {
            get => m_Value.z;
            set => m_Value.z = value;
        }
        public Float2 xy
        {
            get => new Float2(m_Value.x, m_Value.y);
            set => m_Value = new Vector3(value.x, value.y, m_Value.z);
        }
        public Float2 xz
        {
            get => new Float2(m_Value.x, m_Value.z);
            set => m_Value = new Vector3(value.x, m_Value.y, value.y);
        }

        public Float2 yx
        {
            get => new Float2(m_Value.y, m_Value.x);
            set => m_Value = new Vector3(value.y, value.x, m_Value.z);
        }
        public Float2 yz
        {
            get => new Float2(m_Value.y, m_Value.z);
            set => m_Value = new Vector3(m_Value.x, value.x, value.y);
        }
        public Float2 zx
        {
            get => new Float2(m_Value.z, m_Value.x);
            set => m_Value = new Vector3(value.y, m_Value.y, value.x);
        }
        public Float2 zy
        {
            get => new Float2(m_Value.z, m_Value.y);
            set => m_Value = new Vector3(m_Value.x, value.y, value.x);
        }
        public Float3 xyz
        {
            get => new Float3(m_Value.x, m_Value.y, m_Value.z);
            set => m_Value = value;
        }
        public Float3 xzy
        {
            get => new Float3(m_Value.x, m_Value.z, m_Value.y);
            set => m_Value = new Vector3(value.x, value.z, value.y);
        }
        public Float3 yxz
        {
            get => new Float3(m_Value.y, m_Value.x, m_Value.z);
            set => m_Value = new Vector3(value.y, value.x, value.z);
        }
        public Float3 yzx
        {
            get => new Float3(m_Value.y, m_Value.z, m_Value.x);
            set => m_Value = new Vector3(value.y, value.z, value.x);
        }
        public Float3 zyx
        {
            get => new Float3(m_Value.z, m_Value.y, m_Value.x);
            set => m_Value = new Vector3(value.z, value.y, value.x);
        }
        public Float3 zxy
        {
            get => new Float3(m_Value.z, m_Value.x, m_Value.y);
            set => m_Value = new Vector3(value.z, value.x, value.y);
        }
    }

    public struct Float4
    {
        private Vector4 m_Value;

        public static implicit operator Float4(Vector4 v)
            => new Float4 { m_Value = v };

        public static implicit operator Vector4(Float4 v)
            => v.m_Value;

        public Float4(float x)
            => m_Value = new Vector4(x, 0, 0, 0);

        public Float4(float x, float y)
        => m_Value = new Vector4(x, y, 0, 0);

        public Float4(float x, float y, float z)
            => m_Value = new Vector4(x, y, z, 0);

        public Float4(float x, float y, float z, float w)
        => m_Value = new Vector4(x, y, z, w);

        public Float4(Float2 xy, float z, float w)
            => m_Value = new Vector4(xy.x, xy.y, z, w);

        public Float4(float x, Float2 yz, float w)
            => m_Value = new Vector4(x, yz.x, yz.y, w);

        public Float4(float x, float y, Float2 zw)
            => m_Value = new Vector4(x, y, zw.x, zw.y);

        public Float4(Float2 xy, Float2 zw)
            => m_Value = new Vector4(xy.x, xy.y, zw.x, zw.y);

        public Float4(Float3 xyz, float w)
            => m_Value = new Vector4(xyz.x, xyz.y, xyz.z, w);

        public Float4(float x, Float3 yzw)
            => m_Value = new Vector4(x, yzw.x, yzw.y, yzw.z);

        public Float4(Float4 xyzw)
            => m_Value = xyzw;

        // Swizzling
        public float x
        {
            get => m_Value.x;
            set => m_Value.x = value;
        }
        public float y
        {
            get => m_Value.y;
            set => m_Value.y = value;
        }
        public float z
        {
            get => m_Value.z;
            set => m_Value.z = value;
        }
        public float w
        {
            get => m_Value.w;
            set => m_Value.w = value;
        }
        public Float2 xy
        {
            get => new Float2(m_Value.x, m_Value.y);
            set => m_Value = new Vector4(value.x, value.y, m_Value.z, m_Value.w);
        }
        public Float2 xz
        {
            get => new Float2(m_Value.x, m_Value.z);
            set => m_Value = new Vector4(value.x, m_Value.y, value.y, m_Value.w);
        }

        public Float2 yx
        {
            get => new Float2(m_Value.y, m_Value.x);
            set => m_Value = new Vector4(value.y, value.x, m_Value.z, m_Value.w);
        }
        public Float2 yz
        {
            get => new Float2(m_Value.y, m_Value.z);
            set => m_Value = new Vector4(m_Value.x, value.x, value.y, m_Value.w);
        }
        public Float2 zx
        {
            get => new Float2(m_Value.z, m_Value.x);
            set => m_Value = new Vector4(value.y, m_Value.y, value.x, m_Value.w);
        }
        public Float2 zy
        {
            get => new Float2(m_Value.z, m_Value.y);
            set => m_Value = new Vector4(m_Value.x, value.y, value.x, m_Value.w);
        }
        public Float3 xyz
        {
            get => new Float3(m_Value.x, m_Value.y, m_Value.z);
            set => m_Value = new Vector4(value.x, value.y, value.z, m_Value.w);
        }
        public Float3 xzy
        {
            get => new Float3(m_Value.x, m_Value.z, m_Value.y);
            set => m_Value = new Vector4(value.x, value.z, value.y, m_Value.w);
        }
        public Float3 yxz
        {
            get => new Float3(m_Value.y, m_Value.x, m_Value.z);
            set => m_Value = new Vector4(value.y, value.x, value.z, m_Value.w);
        }
        public Float3 yzx
        {
            get => new Float3(m_Value.y, m_Value.z, m_Value.x);
            set => m_Value = new Vector4(value.y, value.z, value.x, m_Value.w);
        }
        public Float3 zyx
        {
            get => new Float3(m_Value.z, m_Value.y, m_Value.x);
            set => m_Value = new Vector4(value.z, value.y, value.x, m_Value.w);
        }
        public Float3 zxy
        {
            get => new Float3(m_Value.z, m_Value.x, m_Value.y);
            set => m_Value = new Vector4(value.z, value.x, value.y, m_Value.w);
        }
        public Float4 xyzw
        {
            get => m_Value;
            set => m_Value = value;
        }
        public Float4 xywz
        {
            get => new Float4(m_Value.x, m_Value.y, m_Value.w, m_Value.z);
            set => m_Value = new Float4(value.x, value.y, value.w, value.z);
        }
        public Float4 xzyw
        {
            get => new Float4(m_Value.x, m_Value.y, m_Value.w, m_Value.z);
            set => m_Value = new Float4(value.x, value.z, value.y, value.w);
        }
        public Float4 xzwy
        {
            get => new Float4(m_Value.x, m_Value.z, m_Value.w, m_Value.y);
            set => m_Value = new Float4(value.x, value.z, value.w, value.y);
        }
        public Float4 xwyz
        {
            get => new Float4(m_Value.x, m_Value.w, m_Value.y, m_Value.z);
            set => m_Value = new Float4(value.x, value.w, value.y, value.z);
        }
        public Float4 xwzy
        {
            get => new Float4(m_Value.x, m_Value.w, m_Value.z, m_Value.y);
            set => m_Value = new Float4(value.x, value.w, value.z, value.y);
        }
        public Float4 yxzw
        {
            get => new Float4(m_Value.y, m_Value.x, m_Value.z, m_Value.w);
            set => m_Value = new Float4(value.y, value.x, value.z, value.w);
        }
        public Float4 yxwz
        {
            get => new Float4(m_Value.y, m_Value.x, m_Value.w, m_Value.z);
            set => m_Value = new Float4(value.y, value.x, value.w, value.z);
        }
        public Float4 yzxw
        {
            get => new Float4(m_Value.y, m_Value.z, m_Value.x, m_Value.w);
            set => m_Value = new Float4(value.y, value.z, value.x, value.w);
        }
        public Float4 yzwx
        {
            get => new Float4(m_Value.y, m_Value.z, m_Value.w, m_Value.x);
            set => m_Value = new Float4(value.y, value.z, value.w, value.x);
        }
        public Float4 ywxz
        {
            get => new Float4(m_Value.y, m_Value.w, m_Value.x, m_Value.z);
            set => m_Value = new Float4(value.y, value.w, value.x, value.z);
        }
        public Float4 ywzx
        {
            get => new Float4(m_Value.y, m_Value.w, m_Value.z, m_Value.x);
            set => m_Value = new Float4(value.y, value.w, value.z, value.x);
        }
        public Float4 zxyw
        {
            get => new Float4(m_Value.z, m_Value.x, m_Value.y, m_Value.w);
            set => m_Value = new Float4(value.z, value.x, value.y, value.w);
        }
        public Float4 zxwy
        {
            get => new Float4(m_Value.z, m_Value.x, m_Value.w, m_Value.y);
            set => m_Value = new Float4(value.z, value.x, value.w, value.y);
        }
        public Float4 zyxw
        {
            get => new Float4(m_Value.z, m_Value.y, m_Value.x, m_Value.w);
            set => m_Value = new Float4(value.z, value.y, value.x, value.w);
        }
        public Float4 zywx
        {
            get => new Float4(m_Value.z, m_Value.y, m_Value.w, m_Value.x);
            set => m_Value = new Float4(value.z, value.y, value.w, value.x);
        }
        public Float4 zwxy
        {
            get => new Float4(m_Value.z, m_Value.w, m_Value.x, m_Value.y);
            set => m_Value = new Float4(value.z, value.w, value.x, value.y);
        }
        public Float4 zwyx
        {
            get => new Float4(m_Value.z, m_Value.w, m_Value.y, m_Value.x);
            set => m_Value = new Float4(value.z, value.w, value.y, value.x);
        }
        public Float4 wxyz
        {
            get => new Float4(m_Value.w, m_Value.x, m_Value.y, m_Value.z);
            set => m_Value = new Float4(value.w, value.x, value.y, value.z);
        }
        public Float4 wxzy
        {
            get => new Float4(m_Value.w, m_Value.x, m_Value.z, m_Value.y);
            set => m_Value = new Float4(value.w, value.x, value.z, value.y);
        }
        public Float4 wyxz
        {
            get => new Float4(m_Value.w, m_Value.y, m_Value.x, m_Value.z);
            set => m_Value = new Float4(value.w, value.y, value.x, value.z);
        }
        public Float4 wyzx
        {
            get => new Float4(m_Value.w, m_Value.y, m_Value.z, m_Value.x);
            set => m_Value = new Float4(value.w, value.y, value.z, value.x);
        }
        public Float4 wzxy
        {
            get => new Float4(m_Value.w, m_Value.z, m_Value.x, m_Value.y);
            set => m_Value = new Float4(value.w, value.z, value.x, value.y);
        }
        public Float4 wzyx
        {
            get => new Float4(m_Value.w, m_Value.z, m_Value.y, m_Value.x);
            set => m_Value = new Float4(value.w, value.z, value.y, value.x);
        }
    }
}
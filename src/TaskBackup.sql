PGDMP                      {           testtask    16.0    16.0     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16397    testtask    DATABASE     �   CREATE DATABASE testtask WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
    DROP DATABASE testtask;
                postgres    false            �            1259    16422    Failure    TABLE     +  CREATE TABLE public."Failure" (
    "Id" integer NOT NULL,
    "Name" character varying(255),
    "MachineName" character varying(255),
    "Priority" integer,
    "StartTime" timestamp without time zone,
    "EndTime" timestamp without time zone,
    "Description" text,
    "IsRemoved" boolean
);
    DROP TABLE public."Failure";
       public         heap    postgres    false            �            1259    16406    Machine    TABLE     g   CREATE TABLE public."Machine" (
    "Id" integer NOT NULL,
    "MachineName" character varying(255)
);
    DROP TABLE public."Machine";
       public         heap    postgres    false            �            1259    16421    failure_id_seq    SEQUENCE     �   CREATE SEQUENCE public.failure_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.failure_id_seq;
       public          postgres    false    218            �           0    0    failure_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.failure_id_seq OWNED BY public."Failure"."Id";
          public          postgres    false    217            �            1259    16405    machines_id_seq    SEQUENCE     �   CREATE SEQUENCE public.machines_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.machines_id_seq;
       public          postgres    false    216            �           0    0    machines_id_seq    SEQUENCE OWNED BY     F   ALTER SEQUENCE public.machines_id_seq OWNED BY public."Machine"."Id";
          public          postgres    false    215                        2604    16425 
   Failure Id    DEFAULT     l   ALTER TABLE ONLY public."Failure" ALTER COLUMN "Id" SET DEFAULT nextval('public.failure_id_seq'::regclass);
 =   ALTER TABLE public."Failure" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    218    217    218                       2604    16409 
   Machine Id    DEFAULT     m   ALTER TABLE ONLY public."Machine" ALTER COLUMN "Id" SET DEFAULT nextval('public.machines_id_seq'::regclass);
 =   ALTER TABLE public."Machine" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    216    215    216            �          0    16422    Failure 
   TABLE DATA           �   COPY public."Failure" ("Id", "Name", "MachineName", "Priority", "StartTime", "EndTime", "Description", "IsRemoved") FROM stdin;
    public          postgres    false    218   �       �          0    16406    Machine 
   TABLE DATA           8   COPY public."Machine" ("Id", "MachineName") FROM stdin;
    public          postgres    false    216   @       �           0    0    failure_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.failure_id_seq', 3, true);
          public          postgres    false    217            �           0    0    machines_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.machines_id_seq', 4, true);
          public          postgres    false    215            $           2606    16429    Failure failure_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Failure"
    ADD CONSTRAINT failure_pkey PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Failure" DROP CONSTRAINT failure_pkey;
       public            postgres    false    218            "           2606    16411    Machine machines_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public."Machine"
    ADD CONSTRAINT machines_pkey PRIMARY KEY ("Id");
 A   ALTER TABLE ONLY public."Machine" DROP CONSTRAINT machines_pkey;
       public            postgres    false    216            �   �   x�m�1�0Eg�� �vT(�ZX�:v�� �Ъ��""a��z�{
�ێ~rԹ��@��((�)�)�"nn�q{&����g�����������<�@��5�5��$|�1�̀�g$���`����{��%�K��NSC      �   (   x�3�,I-.�2S�\�`ڈ˄3/�\!/17�+F��� ��
m     
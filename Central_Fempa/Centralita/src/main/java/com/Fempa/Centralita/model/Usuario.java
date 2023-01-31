package com.Fempa.Centralita.model;

import jakarta.persistence.*;
import net.minidev.json.annotate.JsonIgnore;

import java.util.List;

@Entity
public class Usuario {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;
    private String nombre;
    private String apellidos;
    @Column(unique = true)
    private String dni;
    private String email;
    private String password;
    private int telefono;
    @Column(columnDefinition = "boolean default false")
    private Boolean rol;
    @OneToMany (mappedBy = "atendido_por")
    @JsonIgnore //Para que no se muestre en el JSON de la API
    List<Registro> llamadas_atendidos;
    @OneToMany (mappedBy = "empleado")
    @JsonIgnore //Para que no se muestre en el JSON de la API
    List<Registro> registros_empleado;


    public Usuario() {
    }

    public Usuario(
            String nombre, String apellidos, String dni, String email, String password, int telefono,
                   Boolean rol) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.dni = dni;
        this.email = email;
        this.password = password;
        this.telefono = telefono;
        this.rol = rol;
    }

    public Usuario(
            Long id, String nombre, String apellidos, String dni, String email, String password,
            int telefono, Boolean rol, List<Registro> llamadas_atendidos, List<Registro> registros_empleado) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.dni = dni;
        this.email = email;
        this.password = password;
        this.telefono = telefono;
        this.rol = rol;
        this.llamadas_atendidos = llamadas_atendidos;
        this.registros_empleado = registros_empleado;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public String getDni() {
        return dni;
    }

    public void setDni(String dni) {
        this.dni = dni;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }


    public Boolean getRol() {
        return rol;
    }

    public void setRol(Boolean rol) {
        this.rol = rol;
    }

    public List<Registro> getLlamadas_atendidos() {
        return llamadas_atendidos;
    }

    public void setLlamadas_atendidos(List<Registro> llamadas_atendidos) {
        this.llamadas_atendidos = llamadas_atendidos;
    }

    public List<Registro> getRegistros_empleado() {
        return registros_empleado;
    }

    public void setRegistros_empleado(List<Registro> registros_empleado) {
        this.registros_empleado = registros_empleado;
    }

    @Override
    public String toString() {
        return "Usuario{" +
                "id=" + id +
                ", nombre='" + nombre + '\'' +
                ", apellidos='" + apellidos + '\'' +
                ", dni='" + dni + '\'' +
                ", email='" + email + '\'' +
                ", password='" + password + '\'' +
                ", telefono=" + telefono +
                ", rol=" + rol +
                '}';
    }
}

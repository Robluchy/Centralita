package com.fempa.web.model;

public class Empleado {
    private Long id;
    private int nombre_apellido;
    private String email;
    private String password;
    private String telefono;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public int getNombre_apellido() {
        return nombre_apellido;
    }

    public void setNombre_apellido(int nombre_apellido) {
        this.nombre_apellido = nombre_apellido;
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

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

}
